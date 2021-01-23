using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class Service<T>
    {
        private static T _instance;

        public static void Register(T instance)
        {
            if (_instance != null)
                throw new Exception("Сервис такого типа уже зарегистрирован");
            _instance = instance;
        }

        public static T GetInstance()
        {
            return _instance;
        }
    }
}
