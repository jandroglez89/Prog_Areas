using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.ComponentModel;

namespace Prog_Areas_Plantilla.Controllers
{
    public class Clean_And_Refill
    {
        public static void CleanAllTemplates()
        {
            using (var dbp = new DB_PLANTILLA())
            {
                try
                {
                    dbp.DeleteAllRecords<T_Local>();

                    //Acabados
                    dbp.DeleteAllRecords<T_Ambiente>();
                    dbp.DeleteAllRecords<T_Catalogo_Techo>();
                    dbp.DeleteAllRecords<T_Catalogo_Pared>();
                    dbp.DeleteAllRecords<T_Catalogo_Rodapie>();
                    dbp.DeleteAllRecords<T_Catalogo_Suelo>();
                    dbp.DeleteAllRecords<T_Catalogo_Impermeable>();

                    //Climatizacion
                    dbp.DeleteAllRecords<T_Climatizacion>();

                    dbp.DeleteAllRecords<T_Aire_Fresco>();
                    dbp.DeleteAllRecords<T_AF_Persona>();
                    dbp.DeleteAllRecords<T_AF_Metro_Cuadrado>();

                    dbp.DeleteAllRecords<T_Tratamiento>();
                    dbp.DeleteAllRecords<T_Equipamiento>();
                    dbp.DeleteAllRecords<T_Criterio>();
                    dbp.DeleteAllRecords<T_Renovaciones>();
                    dbp.DeleteAllRecords<T_W_Aire>();

                    //TT_TV
                    dbp.DeleteAllRecords<T_Comunicaciones_Tv>();

                    dbp.DeleteAllRecords<T_TF>();
                    dbp.DeleteAllRecords<T_TD>();
                    dbp.DeleteAllRecords<T_TD_Pos>();
                    dbp.DeleteAllRecords<T_UPSC>();
                    dbp.DeleteAllRecords<T_TT_TV>();
                    dbp.DeleteAllRecords<T_DI>();
                    dbp.DeleteAllRecords<T_ALTV>();
                    dbp.DeleteAllRecords<T_UPSI>();


                    //Alojamiento
                    dbp.DeleteAllRecords<T_Alojamiento_Tipo>();
                    dbp.DeleteAllRecords<T_Alojamiento>();

                    //Otros
                    dbp.DeleteAllRecords<T_CoefArea>();
                    dbp.DeleteAllRecords<T_Mod>();
                    dbp.DeleteAllRecords<T_Tipo_Edificio>();
                    dbp.DeleteAllRecords<T_Porciento_BD>();
                    dbp.DeleteAllRecords<T_LocalTipo>();
                    dbp.DeleteAllRecords<T_Grupo_Locales>();
                    dbp.DeleteAllRecords<T_Subsistema_Area>();
                    dbp.DeleteAllRecords<T_Subsistema_Tipo>();


                    //Reiniciar los contadores de todas las tablas (local y ambiente no tienen autoincremento por lo que no se incluyen)
                    
                    dbp.ReseedTable(typeof(T_Catalogo_Techo));
                    dbp.ReseedTable(typeof(T_Catalogo_Pared));
                    dbp.ReseedTable(typeof(T_Catalogo_Rodapie));
                    dbp.ReseedTable(typeof(T_Catalogo_Suelo));
                    dbp.ReseedTable(typeof(T_Catalogo_Impermeable));
                    dbp.ReseedTable(typeof(T_Climatizacion));
                    dbp.ReseedTable(typeof(T_Aire_Fresco));
                    dbp.ReseedTable(typeof(T_AF_Persona));
                    dbp.ReseedTable(typeof(T_AF_Metro_Cuadrado));
                    dbp.ReseedTable(typeof(T_Tratamiento));
                    dbp.ReseedTable(typeof(T_Equipamiento));
                    dbp.ReseedTable(typeof(T_Criterio));
                    dbp.ReseedTable(typeof(T_Renovaciones));
                    dbp.ReseedTable(typeof(T_W_Aire));
                    dbp.ReseedTable(typeof(T_Comunicaciones_Tv));
                    dbp.ReseedTable(typeof(T_TF));
                    dbp.ReseedTable(typeof(T_TD));
                    dbp.ReseedTable(typeof(T_TD_Pos));
                    dbp.ReseedTable(typeof(T_UPSC));
                    dbp.ReseedTable(typeof(T_TT_TV));
                    dbp.ReseedTable(typeof(T_DI));
                    dbp.ReseedTable(typeof(T_ALTV));
                    dbp.ReseedTable(typeof(T_UPSI));
                    dbp.ReseedTable(typeof(T_CoefArea));
                    dbp.ReseedTable(typeof(T_Alojamiento_Tipo));
                    dbp.ReseedTable(typeof(T_Alojamiento));

                    

                    dbp.ReseedTable(typeof(T_Mod));
                    dbp.ReseedTable(typeof(T_Tipo_Edificio));
                    dbp.ReseedTable(typeof(T_Porciento_BD));
                    dbp.ReseedTable(typeof(T_Grupo_Locales));
                    dbp.ReseedTable(typeof(T_LocalTipo));
                    dbp.ReseedTable(typeof(T_Subsistema_Area));
                    dbp.ReseedTable(typeof(T_Subsistema_Tipo));





                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            //Reimportando todo
            
            ImportarExcel.Singleton();
            
            ReinsertarAcabados.AdicionarAll<T_Catalogo_Suelo>();
            ReinsertarAcabados.AdicionarAll<T_Catalogo_Pared>();
            ReinsertarAcabados.AdicionarAll<T_Catalogo_Techo>();
            ReinsertarAcabados.AdicionarAll<T_Catalogo_Impermeable>();
            ReinsertarAcabados.AdicionarAll<T_Catalogo_Rodapie>();

            ReinsertarAcabados.AdicionarAmbientes();

            ReinsertarSubsistemas.InsertarSubsistemas<T_Subsistema_Tipo>();
            ReinsertarSubsistemas.InsertarSubsistemas<T_Subsistema_Area>();

            ReinsertarAlojamientos.InsertarAlojamiento();

            ReinsertarLocal.InsertarParametros<T_Tratamiento>(22);
            ReinsertarLocal.InsertarParametros<T_Equipamiento>(23);
            ReinsertarLocal.InsertarParametros<T_Criterio>(24);

            ReinsertarLocal.InsertarParametros<T_AF_Metro_Cuadrado>(26);
            ReinsertarLocal.InsertarParametros<T_AF_Persona>(27);
            ReinsertarLocal.InsertarParametros<T_Renovaciones>(28);
            ReinsertarLocal.InsertarParametros<T_W_Aire>(29);

            ReinsertarLocal.InsertarAireFresco();

            ReinsertarLocal.InsertarParametros<T_TF>(30);
            ReinsertarLocal.InsertarParametros<T_TD>(31);
            ReinsertarLocal.InsertarParametros<T_TD_Pos>(32);
            ReinsertarLocal.InsertarParametros<T_UPSC>(33);

            ReinsertarLocal.InsertarParametros<T_UPSI>(34);
            ReinsertarLocal.InsertarParametros<T_TT_TV>(35);
            ReinsertarLocal.InsertarParametros<T_DI>(36);
            ReinsertarLocal.InsertarParametros<T_ALTV>(37);

            ReinsertarGrupoLocales.InsertarGrupoLocales();
            ReinsertarGrupoLocales.InsertarLocalesTipo();

            ReinsertarLocal.InsertarParametroInt<T_Mod>(11);
            ReinsertarLocal.InsertarParametroFloat<T_Porciento_BD>(9);
            ReinsertarLocal.InsertarParametros<T_Tipo_Edificio>(12);

            ReinsertarLocal.InsertarLocales();

            MessageBox.Show("Completado!");
        }

    }
}
