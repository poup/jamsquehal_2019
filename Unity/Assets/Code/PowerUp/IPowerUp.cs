namespace Code
{
    public interface IPowerUp
    {
        bool terminated { get; set; }
        float startTime { get; set; }
    }
}