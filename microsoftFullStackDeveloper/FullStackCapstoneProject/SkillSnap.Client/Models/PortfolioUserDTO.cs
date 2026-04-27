namespace SkillSnap.Client.Models
{
    public class PortfolioUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public List<ProjectDTO> Projects { get; set; } = new List<ProjectDTO>();
        public List<SkillDTO> Skills { get; set; } = new List<SkillDTO>();
    }
}
