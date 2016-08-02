namespace ExceptionHandling_T1
{
    public class Motorsiklet : Urun
    {
        protected override bool InternalUrunSorgula(string parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}