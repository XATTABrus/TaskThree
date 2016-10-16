namespace TaskThree
{
    public class Test
    {
        public Test()
        {
            var processor = new ProcessorBuilder.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
        }
    }
}