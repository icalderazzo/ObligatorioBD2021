using System;
using Obligatorio.Domain.Model; 

namespace Presentation.CustomEvents
{
    public class PostEventArgs : EventArgs
    {
        public Publicacion Post { get; set; }

        public PostEventArgs()
        {

        }

        public PostEventArgs(Publicacion post)
        {
            Post = post;
        }
    }
}
