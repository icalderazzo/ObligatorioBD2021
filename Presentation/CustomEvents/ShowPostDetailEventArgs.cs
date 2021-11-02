using System;
using Obligatorio.Domain.Model; 

namespace Presentation.CustomEvents
{
    public class ShowPostDetailEventArgs : EventArgs
    {
        public Publicacion Post { get; set; }

        public ShowPostDetailEventArgs()
        {

        }

        public ShowPostDetailEventArgs(Publicacion post)
        {
            Post = post;
        }
    }
}
