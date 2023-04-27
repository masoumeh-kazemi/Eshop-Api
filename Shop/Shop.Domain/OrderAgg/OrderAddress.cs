﻿using Common.Domain;

namespace Shop.Domain.OrderAgg;

public class OrderAddress:BaseEntity
{
    public OrderAddress(long orderId, string shire, string city, string postalCode, string postalAddress,
        string phoneNumber, string name, string family, string nationalCode)
    {
        OrderId = orderId;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
    }
    public long OrderId { get; set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }

    //navigation property
    public Order Order { get; set; }
}