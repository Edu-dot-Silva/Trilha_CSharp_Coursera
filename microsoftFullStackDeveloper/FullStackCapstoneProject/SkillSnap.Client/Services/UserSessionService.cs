using SkillSnap.Client.Models;

namespace SkillSnap.Client.Services;

public class UserSessionService
{
    private int? _userId;
    private string _userEmail = "";
    private string _userName = "";
    private string _userRole = "User";
    private Dictionary<int, ProjectDTO> _projectCache = new();
    private Dictionary<int, SkillDTO> _skillCache = new();
    private PortfolioUserDTO? _portfolioUser;

    public int? UserId
    {
        get => _userId;
        set => _userId = value;
    }

    public string UserEmail
    {
        get => _userEmail;
        set => _userEmail = value;
    }

    public string UserName
    {
        get => _userName;
        set => _userName = value;
    }

    public string UserRole
    {
        get => _userRole;
        set => _userRole = value;
    }

    public PortfolioUserDTO? PortfolioUser
    {
        get => _portfolioUser;
        set => _portfolioUser = value;
    }

    public void SetUserInfo(int userId, string email, string name, string role = "User")
    {
        _userId = userId;
        _userEmail = email;
        _userName = name;
        _userRole = role;
    }

    public void CacheProject(ProjectDTO project)
    {
        if (project != null)
            _projectCache[project.Id] = project;
    }

    public ProjectDTO? GetCachedProject(int projectId)
    {
        return _projectCache.TryGetValue(projectId, out var project) ? project : null;
    }

    public void RemoveCachedProject(int projectId)
    {
        _projectCache.Remove(projectId);
    }

    public void CacheSkill(SkillDTO skill)
    {
        if (skill != null)
            _skillCache[skill.Id] = skill;
    }

    public SkillDTO? GetCachedSkill(int skillId)
    {
        return _skillCache.TryGetValue(skillId, out var skill) ? skill : null;
    }

    public void RemoveCachedSkill(int skillId)
    {
        _skillCache.Remove(skillId);
    }

    public void ClearAllCache()
    {
        _projectCache.Clear();
        _skillCache.Clear();
    }

    public void Logout()
    {
        _userId = null;
        _userEmail = "";
        _userName = "";
        _userRole = "User";
        _portfolioUser = null;
        ClearAllCache();
    }

    public bool IsAuthenticated => _userId.HasValue && !string.IsNullOrEmpty(_userEmail);
}
