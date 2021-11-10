using Obligatorio.Domain.Model;
using System;

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
