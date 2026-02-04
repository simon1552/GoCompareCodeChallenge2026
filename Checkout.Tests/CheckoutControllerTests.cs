using AutoFixture;
using System;
using System.Threading.Tasks;
using Xunit;
using Checkout.Api.Controllers;
using Checkout.Api.Domain.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;

namespace Checkout.Tests;

public class CheckoutControllerTests
{
    private readonly AutoMocker _autoMocker = new();
    private readonly Fixture _fixture = new();

    private readonly CheckoutController _subject;

    public CheckoutControllerTests()
    {
        _subject = _autoMocker.CreateInstance<CheckoutController>();
    }

    [Fact]
    public async Task GivenValidRequest_WhenPostCheckout_ThenThrowsNotImplementedException()
    {
        //Given
        var request = _fixture.Create<CheckoutRequest>();

        //When //Then
        await Assert.ThrowsAsync<NotImplementedException>(
            () => _subject.PostCheckout(request));
    }

    
}