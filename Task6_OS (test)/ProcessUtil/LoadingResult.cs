using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_OS
{
    public enum LoadingResult
    {
        Success,                //загрузка в память прошла успешно
        NotEnoughMemory,        //в памяти недостаточно свободных сегментов
        CannotFindFreeSpace,    //памяти достаточно, но она франгментирована. Необходимо уплотнение.
        ProcessSizeIsNull,      //размер процесса - 0 сегментов
        Unknown,                //прочие ошибки
    }
}
