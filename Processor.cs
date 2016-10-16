using System;
using TaskThree;

namespace TaskThree
{
    public class Processor
    {
        public class CreateEngine<TEngine>
        {
            public CreateEngine<TEngine> For<TEntity>()
            {
                return this;
            }

            public void With<TLogger>()
            {
                
            }
        }
    }
}
