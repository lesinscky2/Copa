namespace Copa.Infra.Security.Systems
{
    public interface IBaseCryptography
    {
        byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes);

        byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes);
    }
}