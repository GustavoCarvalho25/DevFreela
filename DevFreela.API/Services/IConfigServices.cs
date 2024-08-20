namespace DevFreela.API.Services
{
    public interface IConfigServices
    {
        int GetValue();
    }

    public class ConfigServices : IConfigServices
    {
        private int _value;

        public int GetValue()
        {
            _value++;
            return _value;
        }
    }
}
