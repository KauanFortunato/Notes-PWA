using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Notes.Data
{
    public class GroupNotes
    {
        private string typeGroup = "data";
        
        public string TypeGroup { 
            set { typeGroup = value; }
            get { return typeGroup; }
        }

    //    private static Task<List<IGrouping<DateTime, Note>>> AgruparNotas(List<Note> notas)
    //    {
    //        List<IGrouping<DateTime, Note>> notasAgrupadas;


    //        switch (typeGroup)
    //        {
    //            case "data":
    //                notasAgrupadas = notas.OrderByDescending(note => note.CreateDate)
    //                                  .GroupBy(note => note.CreateDateDateTime().Date)
    //                                  .ToList();
    //                break;
    //            case "titulo":
    //                notasAgrupadas = notas.OrderByDescending(note => note.CreateDate)
    //                                      .GroupBy(note => note.CreateDateDateTime().Date)
    //                                      .ToList();
    //                break;
    //        }
    //        return notasAgrupadas;
    //    }
    }
}
