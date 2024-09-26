﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user)
        {
            User usuario = user != null ? (User)user : null;
            if (usuario != null && usuario.Id != 0)
                return true;
            else
                return false;
        }

        public static bool EsAdmin(object user)
        {
            User usuario = user != null ? (User)user : null;
            return usuario != null ? usuario.Admin : false ;
        }
    }
}
