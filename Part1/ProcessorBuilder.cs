namespace TaskThree
{
    public class ProcessorBuilder
    {
        public class CreateEngine<TEngine>
        {
            public CreateEngine<TEngine, TEntity> For<TEntity>()
            {
                return new CreateEngine<TEngine, TEntity>();
            }
        }

        public class CreateEngine<TEngine, TEntity>
        {
            public Processor<TEngine, TEntity, TLogger> With<TLogger>()
            {
                return new Processor<TEngine, TEntity, TLogger>();
            }
        }
    }
}
