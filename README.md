# Avaya Agent Screen Pop

Avaya Agent Screen Pop is a custom solution built using .NET Framework for Avaya Aura Contact Center (AACC) in the banking sector. This application provides detailed customer information when a call lands on the agent's desktop, along with various automations that significantly boost agent productivity by 50% in Avaya contact centers.

## Features

- Automatic retrieval of customer information based on incoming calls
- Display of relevant customer details on the agent's desktop
- Integration with Avaya Aura Contact Center (AACC) for real-time data updates
- Advanced automations to streamline agent workflows and improve productivity

## Prerequisites

- Visual Studio (version X.X or higher)
- Avaya Aura Contact Center (AACC) system
- .NET Framework (version 5 or higher)
- IIS Server (version 6 or higher)

## Installation

1. Clone the repository or download the source code.
2. Open the solution file (`AvayaAgentScreenPop.sln`) in Visual Studio.
3. Build the solution to generate the executable files.
4. Deploy the application to an IIS Server (version 6 or higher) or a hosting environment that supports .NET Web Forms.

## Configuration

1. Open the `Web.config` file in the application.
2. Update the Avaya Aura Contact Center (AACC) connection settings in the `<appSettings>` section.
3. Customize the screen layout, information display, and automation workflows in the ASPX files (`*.aspx`) and code-behind files (`*.aspx.cs`).

## Usage

1. Ensure that the application is running and connected to the Avaya Aura Contact Center (AACC) system.
2. When an incoming call is received in the Avaya system, the application will automatically retrieve the customer information.
3. The customer details will be displayed on the agent's desktop, providing valuable insights for personalized and efficient customer service.
4. Take advantage of the built-in automations to streamline agent workflows and enhance productivity.

## Customization

You can customize the application to fit your specific Avaya Aura Contact Center (AACC) system and requirements. Some possible customization options include:

- Integrating with additional Avaya products or services to leverage more features and functionalities.
- Adding or modifying automations to further optimize agent workflows and enhance productivity.
- Implementing additional security measures or access controls based on your organization's requirements.

## Contributing

Contributions to the Avaya Agent Screen Pop project are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
