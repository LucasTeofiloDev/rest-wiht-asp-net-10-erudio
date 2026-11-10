namespace RestWithASPNET10.Data.Converter.Contract
{
    public interface IParser<Origem, Destino>
    {
        Destino Parse(Origem origin);
        List<Destino> ParseList(List<Origem> origin);

    }
}
