using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prog_Areas.Controladores;
using Prog_Areas.Modelos;

namespace Nomencladores
{
    class Program
    {
        static void Main(string[] args)
        {
            Grupo_Locales _gl = new Grupo_Locales() { Value = "Habitación Regular", Cod1 = "1.1" };
            LocalController.InsertarLocalTipo("Habitación Estándar (Doble y Matrimonial)", _gl);

            _gl = new Grupo_Locales() { Value = "Suite(s)", Cod1 = "1.2" };
            LocalController.InsertarLocalTipo("Suite", _gl);

            _gl = new Grupo_Locales() { Value = "Apartamento(s)(especificar Por Tipo)", Cod1 = "1.3" };
            LocalController.InsertarLocalTipo("Apartamento", _gl);
            LocalController.InsertarLocalTipo("Estudio", _gl);
            LocalController.InsertarLocalTipo("Villa", _gl);

            _gl = new Grupo_Locales() { Value = "Ascensores", Cod1 = "1.4" };
            LocalController.InsertarLocalTipo("Ascensores", _gl);

            _gl = new Grupo_Locales() { Value = "Escalera(s)", Cod1 = "1.6" };
            LocalController.InsertarLocalTipo("Circulaciones", _gl);

            _gl = new Grupo_Locales() { Value = "Oficinas Del Frente", Cod1 = "10.1" };
            LocalController.InsertarLocalTipo("Oficinas Del Frente", _gl);

            _gl = new Grupo_Locales() { Value = "Locales / Áreas de La Dirección", Cod1 = "10.2" };
            LocalController.InsertarLocalTipo("Administrativo", _gl);
            LocalController.InsertarLocalTipo("Locales / Áreas de la Dirección", _gl);

            _gl = new Grupo_Locales() { Value = "Locales / Areas Para Otros Destinos", Cod1 = "10.3" };
            LocalController.InsertarLocalTipo("Locales / Áreas para otros destinos", _gl);

            _gl = new Grupo_Locales() { Value = "Locales / Areas de Economia y Contabilidad", Cod1 = "10.4" };
            LocalController.InsertarLocalTipo("Locales / Áreas de Economía y Contabilidad", _gl);

            _gl = new Grupo_Locales() { Value = "Locales / Areas de Empleados", Cod1 = "10.5" };
            LocalController.InsertarLocalTipo("Locales / Áreas de empleados", _gl);

            _gl = new Grupo_Locales() { Value = "Locales / Areas de Empleados", Cod1 = "10.5" };
            LocalController.InsertarLocalTipo("Locales / Áreas de empleados", _gl);

            _gl = new Grupo_Locales() { Value = "Taquillas de Empleados", Cod1 = "10.6" };
            LocalController.InsertarLocalTipo("Taquillas de empleados", _gl);

            _gl = new Grupo_Locales() { Value = "Campos Deportivos Individuales y Multiuso", Cod1 = "11.1" };
            LocalController.InsertarLocalTipo("Campos Deportivos Individuales y Multiuso", _gl);

            _gl = new Grupo_Locales() { Value = "Área(s) de Juegos de Niños", Cod1 = "11.2" };
            LocalController.InsertarLocalTipo("Área(s) de juegos de niños", _gl);

            _gl = new Grupo_Locales() { Value = "Área(s) de Juegos de Niños", Cod1 = "11.2" };
            LocalController.InsertarLocalTipo("Área(s) de juegos de niños", _gl);

            _gl = new Grupo_Locales() { Value = "Minigolf", Cod1 = "11.3" };
            LocalController.InsertarLocalTipo("Minigolf", _gl);

            _gl = new Grupo_Locales() { Value = "Juego(s) Sobre Piso / Césped", Cod1 = "11.4" };
            LocalController.InsertarLocalTipo("Juego(s) sobre piso / césped", _gl);

            _gl = new Grupo_Locales() { Value = "Campo(s) de Tiro", Cod1 = "11.5" };
            LocalController.InsertarLocalTipo("Campo de tiro", _gl);

            _gl = new Grupo_Locales() { Value = "Local(es) de Alquiler De", Cod1 = "11.6" };
            LocalController.InsertarLocalTipo("Locales de Alquiler", _gl);

            _gl = new Grupo_Locales() { Value = "Estacionamiento en Exteriores", Cod1 = "11.7" };
            LocalController.InsertarLocalTipo("Estacionamiento en Exteriores", _gl);

            _gl = new Grupo_Locales() { Value = "Otras Áreas de Otras Actividades(especificar Cada Una)", Cod1 = "11.8" };
            LocalController.InsertarLocalTipo("Garita Entrada Principal", _gl);
            LocalController.InsertarLocalTipo("Garita Entrada Servicio", _gl);
            LocalController.InsertarLocalTipo("Gazebo de Bodas", _gl);

            _gl = new Grupo_Locales() { Value = "Restaurantes", Cod1 = "2.1" };
            LocalController.InsertarLocalTipo("Restaurantes", _gl);
            LocalController.InsertarLocalTipo("Restaurante Buffet", _gl);

            _gl = new Grupo_Locales() { Value = "Restauración Ligera", Cod1 = "2.2" };
            LocalController.InsertarLocalTipo("Restauración Ligera", _gl);
            LocalController.InsertarLocalTipo("Restauración Ligera Bar Restaurante", _gl);
            LocalController.InsertarLocalTipo("Restauración Ligera Parrillada", _gl);
            LocalController.InsertarLocalTipo("Restauración Ligera Ranchón de Playa", _gl);
            LocalController.InsertarLocalTipo("Restauración Ligera Snack Bar", _gl);
            LocalController.InsertarLocalTipo("Áreas VIP", _gl);

            _gl = new Grupo_Locales() { Value = "Bares", Cod1 = "2.3" };
            LocalController.InsertarLocalTipo("Bar(Aqua Bar)", _gl);
            LocalController.InsertarLocalTipo("Bar(Lobby Bar)", _gl);
            LocalController.InsertarLocalTipo("Bar(Piano Bar)", _gl);
            LocalController.InsertarLocalTipo("Bar de Playa", _gl);
            LocalController.InsertarLocalTipo("Bar Mirador", _gl);
            LocalController.InsertarLocalTipo("Bar Temático", _gl);
            LocalController.InsertarLocalTipo("Cigar Bar", _gl);

            _gl = new Grupo_Locales() { Value = "Centros / Actividades Nocturnas", Cod1 = "2.4" };
            LocalController.InsertarLocalTipo("Centros / Actividades Nocturnas", _gl);

            _gl = new Grupo_Locales() { Value = "Servicio(s) Sanitario(s)(especificar)", Cod1 = "2.5" };
            LocalController.InsertarLocalTipo("Servicios Sanitarios Públicos", _gl);

            _gl = new Grupo_Locales() { Value = "Otras Áreas o Locales(especificar)", Cod1 = "3.10" };
            LocalController.InsertarLocalTipo("Otras Áreas", _gl);
            LocalController.InsertarLocalTipo("Otras áreas o locales Público - Comercial", _gl);
            LocalController.InsertarLocalTipo("Público - Comercial", _gl);

            _gl = new Grupo_Locales() { Value = "Vestíbulo Principal", Cod1 = "3.2" };
            LocalController.InsertarLocalTipo("Lobby - Vestíbulo", _gl);

            _gl = new Grupo_Locales() { Value = "Áreas Comerciales", Cod1 = "3.3" };
            LocalController.InsertarLocalTipo("Áreas Comerciales", _gl);

            _gl = new Grupo_Locales() { Value = "Salones / Locales", Cod1 = "3.4" };
            LocalController.InsertarLocalTipo("Salones / Locales", _gl);

            _gl = new Grupo_Locales() { Value = "Teatros", Cod1 = "3.5" };
            LocalController.InsertarLocalTipo("Teatros", _gl);

            _gl = new Grupo_Locales() { Value = "Estacionamiento Interior", Cod1 = "3.6" };
            LocalController.InsertarLocalTipo("Estacionamiento Interior", _gl);

            _gl = new Grupo_Locales() { Value = "Salón de Belleza", Cod1 = "3.7" };
            LocalController.InsertarLocalTipo("Salón de Belleza", _gl);

            _gl = new Grupo_Locales() { Value = "Salón de Belleza", Cod1 = "3.7" };
            LocalController.InsertarLocalTipo("Salón de Belleza", _gl);

            _gl = new Grupo_Locales() { Value = "Local de Servicios Médicos", Cod1 = "3.8" };
            LocalController.InsertarLocalTipo("Servicios Médicos", _gl);

            _gl = new Grupo_Locales() { Value = "Local de Correos - Telex – Fax", Cod1 = "3.9" };
            LocalController.InsertarLocalTipo("Local de Correos - Telex – Fax", _gl);

            _gl = new Grupo_Locales() { Value = "Centro de Salud / Fitness Center", Cod1 = "4.1" };
            LocalController.InsertarLocalTipo("Centro de Salud / Fitness Center", _gl);
            LocalController.InsertarLocalTipo("Club Deportivo", _gl);
            LocalController.InsertarLocalTipo("Gimnasio", _gl);
            LocalController.InsertarLocalTipo("Spa", _gl);

            _gl = new Grupo_Locales() { Value = "Teatro de Animación Techado", Cod1 = "4.10" };
            LocalController.InsertarLocalTipo("Teatro de Animación", _gl);

            _gl = new Grupo_Locales() { Value = "Miniclub Infantil", Cod1 = "4.11" };
            LocalController.InsertarLocalTipo("Club Infantil", _gl);

            _gl = new Grupo_Locales() { Value = "Teatro de Animación Techado", Cod1 = "4.10" };
            LocalController.InsertarLocalTipo("Teatro de Animación", _gl);

            _gl = new Grupo_Locales() { Value = "Otras Áreas de Actividades(especificar)", Cod1 = "4.12" };
            LocalController.InsertarLocalTipo("Recreacional Interiores", _gl);

            _gl = new Grupo_Locales() { Value = "Salón de Lectura", Cod1 = "4.2" };
            LocalController.InsertarLocalTipo("Salón de Lectura", _gl);

            _gl = new Grupo_Locales() { Value = "Local / Área de Juegos de Salón y Billar", Cod1 = "4.3" };
            LocalController.InsertarLocalTipo("Local / Área de juegos", _gl);

            _gl = new Grupo_Locales() { Value = "Bolera", Cod1 = "4.5" };
            LocalController.InsertarLocalTipo("Bolera", _gl);

            _gl = new Grupo_Locales() { Value = "Sala(s) de Multiuso Para Deportes de Raqueta", Cod1 = "4.7" };
            LocalController.InsertarLocalTipo("Sala(s) de multiuso para deportes de raqueta", _gl);

            _gl = new Grupo_Locales() { Value = "Piscina(s)", Cod1 = "5.1" };
            LocalController.InsertarLocalTipo("Local de Toallas", _gl);
            LocalController.InsertarLocalTipo("Piscina", _gl);

            _gl = new Grupo_Locales() { Value = "Locales de Ama de Llaves", Cod1 = "6.1" };
            LocalController.InsertarLocalTipo("Locales de Ama de llaves", _gl);

            _gl = new Grupo_Locales() { Value = "Local(es) de Camareras", Cod1 = "6.2" };
            LocalController.InsertarLocalTipo("Locales de Camareras", _gl);

            _gl = new Grupo_Locales() { Value = "Servicio de Lavandería y de Tintorería", Cod1 = "6.3" };
            LocalController.InsertarLocalTipo("Servicio de Lavandería y Tintorería", _gl);

            _gl = new Grupo_Locales() { Value = "Zona o Área de Carga y Descarga", Cod1 = "7.1" };
            LocalController.InsertarLocalTipo("Área de carga y descarga", _gl);

            _gl = new Grupo_Locales() { Value = "Almacenes Climatizados", Cod1 = "7.3" };
            LocalController.InsertarLocalTipo("Almacenes Climatizados", _gl);

            _gl = new Grupo_Locales() { Value = "Almacenes / Locales No Climatizados", Cod1 = "7.4" };
            LocalController.InsertarLocalTipo("Almacenes No Climatizados", _gl);

            _gl = new Grupo_Locales() { Value = "Área de Pre – Elaboración y Preparación", Cod1 = "7.5" };
            LocalController.InsertarLocalTipo("Cocina Central - Área de Pre–elaboración y Preparación", _gl);

            _gl = new Grupo_Locales() { Value = "Cocina Central", Cod1 = "7.6" };
            LocalController.InsertarLocalTipo("Cocina Apoyo", _gl);
            LocalController.InsertarLocalTipo("Cocina Central", _gl);

            _gl = new Grupo_Locales() { Value = "Apoyos de Servicios", Cod1 = "7.7" };
            LocalController.InsertarLocalTipo("Apoyo de Servicios", _gl);

            _gl = new Grupo_Locales() { Value = "Locales / Áreas de Talleres y Oficinas", Cod1 = "9.1" };
            LocalController.InsertarLocalTipo("Locales / Áreas de Talleres y Oficinas", _gl);

            _gl = new Grupo_Locales() { Value = "Áreas / Locales Tecnicos", Cod1 = "9.2" };
            LocalController.InsertarLocalTipo("Áreas / Locales Técnicos", _gl);

        }
    }
}
