using System;
using Moq;
using NoisEmap.Application.Services;
using NoisEmap.Domain.Entities;
using NoisEmap.Domain.Interfaces;
using Xunit;

public class SensorServiceTests
{
    private readonly Mock<ISensorRepository> _repoMock;
    private readonly Mock<ISensorMongoRepository> _mongoMock;
    private readonly SensorService _service;

    public SensorServiceTests()
    {
        _repoMock = new Mock<ISensorRepository>();
        _mongoMock = new Mock<ISensorMongoRepository>();
        _service = new SensorService(_repoMock.Object, _mongoMock.Object);
    }

    [Fact]
    public void Add_TemperaturaValida_AdicionaSensor()
    {
        // Arrange
        var sensor = new Sensor { Id = 1, Temperatura = 25, Umidade = 70 };
        // Act
        _service.Add(sensor);
        // Assert
        _mongoMock.Verify(m => m.Insert(sensor), Times.Once);
    }

    [Fact]
    public void Add_TemperaturaInvalida_LancaExcecao()
    {
        // Arrange
        var sensor = new Sensor { Id = 2, Temperatura = 200, Umidade = 50 };
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _service.Add(sensor));
    }

    [Fact]
    public void Add_TemperaturaAbaixoDoMinimo_LancaExcecao()
    {
        var sensor = new Sensor { Temperatura = -51, Umidade = 60 };
        Assert.Throws<ArgumentException>(() => _service.Add(sensor));
    }

    [Fact]
    public void Add_Invalido_NaoInsereMongo()
    {
        var sensor = new Sensor { Temperatura = 200, Umidade = 60 };
        Assert.Throws<ArgumentException>(() => _service.Add(sensor));
        _mongoMock.Verify(m => m.Insert(It.IsAny<Sensor>()), Times.Never);
    }

    [Fact]
    public void GetById_SensorExistente_RetornaSensor()
    {
        // Arrange
        var sensor = new Sensor { Id = 1, Temperatura = 25, Umidade = 70 };
        _repoMock.Setup(r => r.GetById(1)).Returns(sensor);
        // Act
        var resultado = _service.GetById(1);
        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(1, resultado.Id);
    }

    [Fact]
    public void GetById_SensorInexistente_RetornaNull()
    {
        // Arrange
        _repoMock.Setup(r => r.GetById(99)).Returns((Sensor?)null);
        // Act
        var resultado = _service.GetById(99);
        // Assert
        Assert.Null(resultado);
    }

    [Fact]
    public void Delete_SensorExistente_ChamaRepositorio()
    {
        // Arrange & Act
        _service.Delete(1);
        // Assert
        _repoMock.Verify(r => r.Delete(1), Times.Once);
    }
}