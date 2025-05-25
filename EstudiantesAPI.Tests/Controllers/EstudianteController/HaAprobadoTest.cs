using Moq;
using EstudiantesAPI.Controller;
using EstudiantesAPI.Services;
using EstudiantesAPI.Models;

public class EstudianteControllerTests
{
    [Fact]
    public void HaAprobadoVerdadero()
    {
        // Arrange
        var mockService = new Mock<IEstudianteService>();
        mockService.Setup(s => s.GetByCI(13721137)).Returns(new Estudiante
        {
            CI = 13721137,
            Nombre = "Juan Perez",
            Nota = 75
        });
        mockService.Setup(s => s.HaAprobado(It.IsAny<Estudiante>())).Returns<Estudiante>(e => e.Nota >= 51);

        // Act
        var controller = new EstudianteController(mockService.Object);
        var resultado = controller.HaAprobado(13721137);

        // Assert
        Assert.Equal("Juan Perez con CI 13721137 ha aprobado.", resultado.Value);

    }

    [Fact]
    public void HaAprobadoFalso()
    {
        // Arrange
        var mockService = new Mock<IEstudianteService>();
        mockService.Setup(s => s.GetByCI(13721137)).Returns(new Estudiante
        {
            CI = 13721137,
            Nombre = "Juan Perez",
            Nota = 45
        });
        mockService.Setup(s => s.HaAprobado(It.IsAny<Estudiante>())).Returns<Estudiante>(e => e.Nota >= 51);
        // Act
        var controller = new EstudianteController(mockService.Object);
        var resultado = controller.HaAprobado(13721137);
        
        // Assert
        Assert.Equal("Juan Perez con CI 13721137 no ha aprobado.", resultado.Value);
    }

    [Fact]
    public void HaAprobadoNombreCorrecto()
    {
        // Arrange
        var mockService = new Mock<IEstudianteService>();
        mockService.Setup(s => s.GetByCI(12345678)).Returns(new Estudiante
        {
            CI = 12345678,
            Nombre = "Maria Lopez",
            Nota = 80
        });
        mockService.Setup(s => s.HaAprobado(It.IsAny<Estudiante>())).Returns<Estudiante>(e => e.Nota >= 51);
        // Act
        var controller = new EstudianteController(mockService.Object);
        var resultado = controller.HaAprobado(12345678);
        
        // Assert
        Assert.Contains("Maria Lopez", resultado.Value);
    }

    [Fact]
    public void HaAprobadoCICorrecto()
    {
        // Arrange
        var mockService = new Mock<IEstudianteService>();
        mockService.Setup(s => s.GetByCI(87654321)).Returns(new Estudiante
        {
            CI = 87654321,
            Nombre = "Carlos Ruiz",
            Nota = 60
        });
        mockService.Setup(s => s.HaAprobado(It.IsAny<Estudiante>())).Returns<Estudiante>(e => e.Nota >= 51);
        // Act
        var controller = new EstudianteController(mockService.Object);
        var resultado = controller.HaAprobado(87654321);
        // Assert
        Assert.Contains("87654321", resultado.Value);
    }
}