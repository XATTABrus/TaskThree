namespace TaskThree
{
    public class Test
    {
        public Test()
        {
            new Processor.CreateEngine<MyEngine>().For<MyEntity>().With<MyLogger>();
        }
    }
}