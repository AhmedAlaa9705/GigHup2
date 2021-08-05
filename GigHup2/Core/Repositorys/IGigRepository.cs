using GigHup2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHup2.Core.Repositorys
{
    public interface IGigRepository
    {
         Gig GetGig(int gigid);
        IEnumerable<Gig> GetUpComingGigs(string artistId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetGigsUserAttending(string userid);
        void Add(Gig gig);

    }
}
