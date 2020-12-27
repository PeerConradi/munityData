using System;
using System.Collections.Generic;
using System.Text;
using MUNitySchema.Models.ListOfSpeakers;
using System.Linq;
using static MUNitySchema.Models.ListOfSpeakers.ListOfSpeakers;

namespace MUNity.Extensions.LoSExtensions
{
    public static class ListOfSpeakersExtensions
    {
        public static void NextSpeaker(this ListOfSpeakers list)
        {
            if (list.Speakers.Any())
            {
                list.CurrentSpeaker = list.Speakers.First();
                list.Speakers.Remove(list.Speakers.First());
            }
            list.Status = EStatus.Stopped;
            //list.ListChanged?.Invoke();
        }
    }
}
