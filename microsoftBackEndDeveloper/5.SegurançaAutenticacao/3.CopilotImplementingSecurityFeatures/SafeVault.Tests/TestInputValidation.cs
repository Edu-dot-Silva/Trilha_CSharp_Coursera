[TestFixture]
public class TestInputValidation
{
    [Test]
    public void TestForSQLInjection()
    {
        string maliciousInput = "'; DROP TABLE Users; --";
        string sanitized = InputSanitizer.SanitizeUsername(maliciousInput);

        Assert.False(sanitized.Contains("DROP"), "SQL injection deve ser bloqueado.");
    }

    [Test]
    public void TestForXSS()
    {
        string maliciousInput = "<script>alert('XSS');</script>";
        string sanitized = InputSanitizer.SanitizeUsername(maliciousInput);

        Assert.False(sanitized.Contains("<script>"), "XSS deve ser bloqueado.");
    }
}
