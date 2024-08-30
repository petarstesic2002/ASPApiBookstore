namespace ASPProjekat.API
{
    public class AppSettings
    {
        public string ConnectionString {  get; set; }= "Data Source=DESKTOP-54K3IOI\\SQLEXPRESS;Initial Catalog=ASPBookstore;Integrated Security=True;Trust Server Certificate=True";
        public JwtSettings Jwt { get; set; }
        public string PasswordSalt { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "597e3b12820151caa6062612caec8056";
        public int DurationSeconds { get; set; }
        public string Issuer { get; set; }
    }
}
