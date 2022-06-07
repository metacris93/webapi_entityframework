namespace webapi.Services
{
  public class SampleService : ISampleService
  {
    public string GetHelloWorld()
    {
      return "Hello World";
    }
  }
  public interface ISampleService
  {
    string GetHelloWorld();
  }
}