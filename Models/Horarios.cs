namespace Login.Models{
    public class Horario{

        public int id{get; set; }
        public string Dia {get; set;}
        public DateTime HoraIngreso {get; set;} = DateTime.Now;
        public DateTime? HoraSalida {get; set;} = null;
        public int IdEmpleado {get; set;}
    }
}