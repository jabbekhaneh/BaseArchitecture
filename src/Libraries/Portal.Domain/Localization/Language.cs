namespace Portal.Domain.Localization;

public class Language : BaseEntity
{

    public Language(string name, string title, bool isRtl = false)
    {
        if (name == null)
            throw new ArgumentNullException("name");
        if (title == null)
            throw new ArgumentNullException("title");
        this.Name = name.ToLower();
        this.IsRtl = isRtl;
        Title = title.ToLower();
    }

    public string Name { get; private set; } = string.Empty;
    public string Title { get; private set; } = string.Empty;
    public bool IsRtl { get; private set; } = false;

    public Language Edit(string name, string title,bool isRtl)
    {
        this.Title = title.ToLower();
        this.Name = name.ToLower();
        this.IsRtl = isRtl;
        return this;
    }
}
