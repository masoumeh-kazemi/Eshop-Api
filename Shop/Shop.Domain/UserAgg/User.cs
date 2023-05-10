using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg;

public class User:AggregateRoot
{
    public User(string name, string family, string phoneNumber, string email, string password,
        Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Password = password;
        Gender = gender;
        AvatarName = "avatar.png";
    }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string AvatarName { get; private set; }
    public Gender Gender { get; private set; }
    public List<UserRole> Roles { get; private set; }
    public List<Wallet> Wallets { get; private set; }
    public List<UserAddress> Addresses { get; private set; }

    public void Edit(string name, string family, string phoneNumber, string email,
        Gender gender, IUserDomainService userDomainService)
    {
        Guard(phoneNumber, email, userDomainService);
        Name = name;
        Family = family;
        PhoneNumber = phoneNumber;
        Email = email;
        Gender = gender;
    }

    public void SetAvatar(string imageName)
    {
        if (string.IsNullOrWhiteSpace(imageName))
            imageName = "avatar.png";

        AvatarName = imageName;
    }

    public static User Register(string phoneNumber ,string password, IUserDomainService userDomainService)
    {
        return new User("", "", phoneNumber, null, password, Enums.Gender.None, userDomainService);
    }
    public void AddAddress(UserAddress address)
    {
        address.UserId = Id;
        Addresses.Add(address);
    }

    public void DeleteAddress(long addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f => f.Id == addressId);
        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not Found");

        Addresses.Remove(oldAddress);
    }
    public void EditAddress(UserAddress address, long addressId)
    {
        var oldAddress = Addresses.FirstOrDefault(f=>f.Id == addressId);
        if (oldAddress == null)
            throw new NullOrEmptyDomainDataException("Address Not Found");

        oldAddress.Edit(address.Shire, address.City, address.PostalCode, address.PostalAddress, address.PhoneNumber, address.Name
        ,address.Family,address.NationalCode);


    }

    public void ChargeWallet(Wallet wallet)
    {
        wallet.UserId = Id;
        Wallets.Add(wallet);
    }

    public void SetRoles(List<UserRole> roles)
    {
        roles.ForEach(f=>f.UserId = Id);
        Roles.Clear();
        Roles.AddRange(roles);
    }

    public void Guard(string phoneNumber, string email, IUserDomainService userDomainService)
    {
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(email, nameof(email));
        if (phoneNumber.Length != 11)
            throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
        if (email.IsValidEmail() == false)
            throw new InvalidDomainDataException("ایمیل ناعتبر است");
        if(phoneNumber != PhoneNumber)
            if (userDomainService.PhoneNumberIsExist(phoneNumber))
                throw new InvalidDomainDataException("شماره موبایل تکراری است");
        if (email != Email)
            if (userDomainService.IsEmailExist(email))
                throw new InvalidDomainDataException("ایمیل تکراری است");

    }
}