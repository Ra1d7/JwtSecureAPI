# C# .NET Core API with Jwt Tokens, Authentication and Authorization
This C# .NET Core API provides an implementation of Json Web Tokens (Jwt) for securing API endpoints and a setup of Authentication and Authorization policies.
<p align="center">
  <img src="https://user-images.githubusercontent.com/25421570/232620369-5615d475-27d0-44d6-ab5d-910a083691d9.png" alt="Why-Cant-I-Just-Send-JWTs-Without-OAuth-JWT" width="50%" height="50%" />
</p>

## Features

- User registration and login with Jwt tokens
- Authentication middleware for verifying Jwt tokens
- Authorization middleware for managing user roles and permissions
- Custom policy-based Authorization for fine-grained control over API endpoints access
- Swagger UI for API documentation

## Prerequisites

- Visual Studio or Visual Studio Code
- .NET Core SDK
- MongoDB or any other NoSQL database

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or Visual Studio Code
3. Run the API project
4. Navigate to `https://localhost:7035/swagger/index.html` to view the Swagger UI and the API endpoints

## Jwt Tokens

Jwt tokens are used for authentication and authorization of API endpoints. A user is required to register or login to get a token that they can use to access authorized endpoints.

## Authentication

The API provides an authentication middleware that verifies Jwt tokens sent by the client. The middleware can be added to any endpoint that requires authentication.

## Authorization

The API provides an authorization middleware that manages user roles and permissions. The middleware can be added to any endpoint that requires authorization.

## Custom policy-based Authorization

The API provides a custom policy-based authorization middleware that provides fine-grained control over API endpoints access. The middleware allows for specifying policies based on user roles and permissions.

## Swagger UI

The API provides a Swagger UI that documents all the API endpoints and their parameters. The Swagger UI is accessible at `https://localhost:7035/swagger/index.html`.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
