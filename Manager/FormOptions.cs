//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE.
//
//  License: GNU Lesser General Public License (LGPLv3)
//
//  Email: pumpet.net@gmail.com
//  Git: https://github.com/Pumpet/Robin
//  Copyright (C) Alex Rozanov, 2020 
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Common;

namespace Manager {

    public enum FormOptionsSetType { Size, Grid, All }
    /// <summary>Контейнер параметров форм
    /// </summary>
    public class FormsConfig {
        string fileName;
        [XmlArrayItem("Form")]
        public List<FormOptions> Forms = new List<FormOptions>();

        /// <summary>Заполняет контейнер параметров форм из файла. Если файла нет - создает новый.
        /// </summary>
        /// <param name="fileName">имя файла, по умолчанию: Forms + имя приложения.xml</param>
        /// <returns>контейнер параметров форм</returns>
        internal static FormsConfig CreateFromFile(string fileName = "") {
            FormsConfig config = null;
            if (string.IsNullOrWhiteSpace(fileName))
                fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Forms" + Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName) + ".xml");
            try {
                if (!File.Exists(fileName))
                    OptionsSerializer.Save(fileName, new FormsConfig());
                config = OptionsSerializer.Load<FormsConfig>(fileName);
                if (config != null)
                    config.fileName = fileName;
            }
            catch (Exception ex) {
                Loger.SendMess(ex, $"Ошибка загрузки параметров форм из файла {fileName}");
            }
            return config;
        }

        internal static FormsConfig CreateFromXML(string xml) {
            FormsConfig config = null;
            if (!string.IsNullOrWhiteSpace(xml))
                try {
                    config = OptionsSerializer.LoadXML<FormsConfig>(xml);
                }
                catch (Exception ex) {
                    Loger.SendMess(ex, $"Ошибка загрузки параметров форм из строки");
                    xml = null;
                }
            if (string.IsNullOrWhiteSpace(xml))
                config = new FormsConfig();
            return config;
        }

        /// <summary>Запись контейнера в файл
        /// </summary>
        internal void Save() {
            OptionsSerializer.Save(fileName, this);
        }

        internal string GetXML() {
            return OptionsSerializer.GetXML(this);
        }

        // установить параметры для формы
        internal void SetToForm(Form form, FormOptionsSetType setType = FormOptionsSetType.All) {
            string mode = form.StartPosition == FormStartPosition.CenterParent ? "Parent" : "Default";
            FormOptions opt = Forms.FirstOrDefault(x => x.Name == form.Name && x.Mode == mode);
            if (opt == null) return;

            if (setType == FormOptionsSetType.All || setType == FormOptionsSetType.Size) {
                if (opt.Width >= form.MinimumSize.Width)
                    form.Width = opt.Width;
                //else
                //    form.Width = form.MinimumSize.Width > 0 ? form.MinimumSize.Width : 100;
                if (opt.Height >= form.MinimumSize.Height)
                    form.Height = opt.Height;
                //else
                //    form.Height = form.MinimumSize.Height > 0 ? form.MinimumSize.Height : 100;
                if (AppConfig.HasProp("RestoreFormPos")) {
                    form.Top = opt.Top;
                    form.Left = opt.Left;
                }
            }

            if (setType == FormOptionsSetType.All)
                foreach (var item in opt.Splits) {
                    Control c = form.GetControl(item.Name);
                    if (c is SplitContainer && item.Distance > 0) {
                        var sc = (SplitContainer)c;
                        if ((sc.Orientation == Orientation.Horizontal && item.Distance < form.Height)
                            || (sc.Orientation == Orientation.Vertical && item.Distance < form.Width))
                        sc.SplitterDistance = item.Distance;
                        sc.Panel1Collapsed = item.Panel1Collapsed;
                        sc.Panel2Collapsed = item.Panel2Collapsed;
                    }
                }

            if (setType == FormOptionsSetType.All || setType == FormOptionsSetType.Grid)
                foreach (var item in opt.Grids) {
                    Control c = form.GetControl(item.Name);
                    if (c is DataGridView) {
                        DataGridView g = ((DataGridView)c);
                        foreach (DataGridViewColumn col in g.Columns) {
                            ColumnOptions copt = item.Columns.FirstOrDefault(x => x.Name == col.Name);
                            if (copt != null) {
                                col.Width = copt.Width;
                                if (copt.Pos >= 0 && copt.Pos < g.Columns.Count)
                                    col.DisplayIndex = copt.Pos;
                                else
                                    col.DisplayIndex = g.Columns.Count - 1;
                                col.Visible = copt.Visible; 
                            }
                        }
                        var colCheck = g.Columns[GridOptions.checkColumnName];
                        if (colCheck != null) colCheck.DisplayIndex = 0;
                    }
                }

            if (setType == FormOptionsSetType.All && form is IDataForm) {
                ((IDataForm)form).SetUiParamsProperties(opt.ControlValues);
            }
        }

        // загрузить параметры из формы
        internal void GetFromForm(Form form) {
            string mode = form.StartPosition == FormStartPosition.CenterParent ? "Parent" : "Default";
            FormOptions opt = Forms.FirstOrDefault(x => x.Name == form.Name && x.Mode == mode);
            if (opt == null) {
                opt = new FormOptions() { Name = form.Name, Mode = mode };
                Forms.Add(opt);
            }

            if (form.WindowState == FormWindowState.Normal) {
                opt.Top = form.Top;
                opt.Left = form.Left;
                opt.Width = form.Width;
                opt.Height = form.Height;
            }

            opt.Grids.Clear();
            form.ForControls((c) => {
                if (c is DataGridView)
                    opt.Grids.Add(new GridOptions((DataGridView)c));
            });

            opt.Splits.Clear();
            form.ForControls((c) => {
                opt.Splits.Add(new SplitOptions() {
                    Name = c.Name,
                    Distance = ((SplitContainer)c).SplitterDistance,
                    Panel1Collapsed = ((SplitContainer)c).Panel1Collapsed,
                    Panel2Collapsed = ((SplitContainer)c).Panel2Collapsed
                });
            }, typeof(SplitContainer));

            if (form is IDataForm) {
                opt.ControlValues.Clear();
                opt.ControlValues = ((IDataForm)form).PrepareUiParamsProperties(opt.ControlValues);
            }
        }
    }

    /// <summary>Параметры отображения формы
    /// </summary>
    public class FormOptions {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Mode { get; set; }
        [XmlAttribute]
        public int Top { get; set; }
        [XmlAttribute]
        public int Left { get; set; }
        [XmlAttribute]
        public int Width { get; set; }
        [XmlAttribute]
        public int Height { get; set; }

        [XmlArrayItem("Grid")]
        public List<GridOptions> Grids = new List<GridOptions>();
        [XmlArrayItem("Split")]
        public List<SplitOptions> Splits = new List<SplitOptions>();
        [XmlArrayItem("ControlProperty")]
        public List<ControlValue> ControlValues = new List<ControlValue>();

        /// <summary>Загрузить параметры отображения из файла и присвоить форме
        /// </summary>
        public static void LoadFromFile(Form form, string fileName = "", FormOptionsSetType setType = FormOptionsSetType.All) {
            if (form == null) return;
            FormsConfig.CreateFromFile(fileName)?.SetToForm(form, setType);
        }

        /// <summary>Загрузить параметры отображения из XML и присвоить форме
        /// </summary>
        public static void LoadFromXML(Form form, string xml, FormOptionsSetType setType = FormOptionsSetType.All) {
            if (form == null) return;
            FormsConfig.CreateFromXML(xml)?.SetToForm(form, setType);
        }

        /// <summary>Сохранить параметры отображения формы в файле (изменить существующие)
        /// </summary>
        public static void SaveToFile(Form form, string fileName = "") {
            if (form == null) return;
            FormsConfig config = FormsConfig.CreateFromFile(fileName);
            if (config == null) return;
            config.GetFromForm(form);
            config.Save();
        }

        /// <summary>Изменить/добавить параметры отображения формы в строке настроек форм (xml)
        /// </summary>
        public static string GetInXML(Form form, string xml) {
            if (form == null) return xml;
            FormsConfig config = FormsConfig.CreateFromXML(xml);
            if (config == null) return xml;
            config.GetFromForm(form);
            return config.GetXML() ?? xml; 
        }
    }
    
    /// <summary>Параметры отображения грида
    /// </summary>
    public class GridOptions {
        public readonly static string checkColumnName = "#check"; // имя контрольного столбца с checkBox
        [XmlAttribute]
        public string Name { get; set; }
        [XmlArrayItem("Column")]
        public List<ColumnOptions> Columns = new List<ColumnOptions>();

        public GridOptions() { }

        /// <summary>Взять параметры отображения из указанного грида
        /// </summary>
        /// <param name="grid">грид</param>
        public GridOptions(DataGridView grid) {
            Name = grid.Name;
            foreach (DataGridViewColumn c in grid.Columns)
                if (!c.Name.Equals(checkColumnName))
                    Columns.Add(new ColumnOptions() { Name = c.Name, Width = c.Width, Pos = c.DisplayIndex, Visible = c.Visible });
        }
    }
    
    /// <summary>Параметры отображения столбца грида
    /// </summary>
    public class ColumnOptions {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Width { get; set; }
        [XmlAttribute]
        public int Pos { get; set; }
        [XmlAttribute]
        public bool Visible { get; set; }
    }
    
    /// <summary>Параметры отображения сплиттера
    /// </summary>
    public class SplitOptions {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Distance { get; set; }
        [XmlAttribute]
        public bool Panel1Collapsed { get; set; }
        [XmlAttribute]
        public bool Panel2Collapsed { get; set; }
    }

    /// <summary>Для сохранения необходимого свойства необходимого контрола (например используемого в параметрах)</summary>
    public class ControlValue {
        [XmlAttribute]
        public string TypeName { get; set; }
        [XmlAttribute]
        public string Name { get; set; }

        // имя свойства, значение которого храним - пока не используется, т.к. сохраняем одно какое-то свойство, в зависимости от типа
        // если делать сохранение/восстановление нескольких свойств контрола и через рефлексию - тогда наверное понадобится...
        //[XmlAttribute]
        //public string PropName { get; set; } 

        [XmlAttribute]
        public string Value { get; set; }
    }
}
