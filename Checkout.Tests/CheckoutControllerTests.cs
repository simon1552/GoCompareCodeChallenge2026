using AutoFixture;

using System.Net;
using Checkout.Api.Controllers;
using Checkout.Api.Domain.Models;
using Checkout.Api.Domain.Services.Interface;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
    public async Task GivenValidRequest_WhenPostCheckout_ThenReturns200OK()
    {
        //Given
        //Set up fixtures
        var request = _fixture.Create<CheckoutRequest>();
        var total = _fixture.Create<int>();

        //Set up mocks
        _autoMocker.GetMock<ICheckoutService>()
            .Setup(service => service.PriceAsync(request))
            .ReturnsAsync(total);

        //When
        var result = (OkObjectResult)await _subject.PostCheckout(request);

        //Then
        //FluentAssertion
        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }

    [Fact]
    public async Task GivenValidRequestThrowsException_WhenPostCheckout_ThenReturns500InternalServerError()
    {
        //Given
        var request = _fixture.Create<CheckoutRequest>();

        _autoMocker.GetMock<ICheckoutService>()
            .Setup(service => service.PriceAsync(request))
            .ThrowsAsync(new Exception("Failed to get request from body"));

        //When
        var result = (ObjectResult)await _subject.PostCheckout(request);

        //Then
        result.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
    }
}