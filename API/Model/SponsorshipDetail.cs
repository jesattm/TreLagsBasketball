namespace API.Model
{
    public class SponsorshipDetail
    {
        public SponsorshipDetail()
        {
        }
        public SponsorshipDetail(DTO.Model.SponsorshipDetail sponsorshipDetail)
        {
            SponsorshipDetailId = sponsorshipDetail.SponsorshipId;
            SponsorshipDetailName = sponsorshipDetail.SponsorshipName;
            Players = DTOPlayersToAPIPlayers(sponsorshipDetail.Players);
        }

        public int SponsorshipDetailId { get; set; }
        public string SponsorshipDetailName { get; set; }
        public virtual List<Player> Players { get; set; }
        private List<Player> DTOPlayersToAPIPlayers(List<DTO.Model.Player> DTOPlayers)
        {
            List<Player> APIPlayers = new List<Player>();
            foreach (DTO.Model.Player DTOPlayer in DTOPlayers)
            {
                Player MVCPlayer = new Player(DTOPlayer);
                APIPlayers.Add(MVCPlayer);
            }
            return APIPlayers;
        }

    }
}
