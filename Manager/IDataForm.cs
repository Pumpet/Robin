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

using System.Collections.Generic;

namespace Manager {

    /// <summary>Интерфейс для взаимодействия контекста с библиотечными формами</summary>
    public interface IDataForm {

        /// <summary>Инициализация формы</summary>
        /// <param name="ctx">Контекст приложения</param>
        /// <param name="formModes">Режимы запуска</param>
        /// <param name="extParams">Параметры для запросов</param>
        /// <param name="key">Ключ записи (например чтобы встать на нужной строке в главном гриде формы списка)</param>
        void Init(Context ctx, FormModes formModes = FormModes.Default, Dictionary<string, object> extParams = null, object key = null);

        /// <summary>Подготовка значений полей параметров для сохранения</summary>
        List<ControlValue> PrepareUiParamsProperties(List<ControlValue> props);

        /// <summary>Установка загруженных значений полей параметров</summary>
        void SetUiParamsProperties(List<ControlValue> props);
    }
}
