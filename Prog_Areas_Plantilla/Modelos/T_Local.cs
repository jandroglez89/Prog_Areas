//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prog_Areas_Plantilla.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Local
    {
        public int RoomId { get; set; }
        public string Key_Name { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Habitacion { get; set; }
        public Nullable<int> SubsistemaTipo { get; set; }
        public Nullable<int> SubsistemaArea { get; set; }
        public Nullable<int> Climatizacion { get; set; }
        public Nullable<int> Comunicaciones_TV { get; set; }
        public Nullable<int> Ambiente { get; set; }
        public Nullable<int> Coef_Area { get; set; }
        public Nullable<int> Mod { get; set; }
        public Nullable<int> Tipo_Edificio { get; set; }
        public Nullable<int> Porciento_BD { get; set; }
        public Nullable<int> Alojamiento { get; set; }
        public Nullable<int> Grupo_Local { get; set; }
        public Nullable<int> LocalTipo { get; set; }
    
        public virtual T_Alojamiento T_Alojamiento { get; set; }
        public virtual T_Ambiente T_Ambiente { get; set; }
        public virtual T_Climatizacion T_Climatizacion { get; set; }
        public virtual T_CoefArea T_CoefArea { get; set; }
        public virtual T_Comunicaciones_Tv T_Comunicaciones_Tv { get; set; }
        public virtual T_Grupo_Locales T_Grupo_Locales { get; set; }
        public virtual T_Subsistema_Area T_Subsistema_Area { get; set; }
        public virtual T_Subsistema_Tipo T_Subsistema_Tipo { get; set; }
        public virtual T_Mod T_Mod { get; set; }
        public virtual T_Porciento_BD T_Porciento_BD { get; set; }
        public virtual T_Tipo_Edificio T_Tipo_Edificio { get; set; }
        public virtual T_LocalTipo T_LocalTipo { get; set; }
    }
}
