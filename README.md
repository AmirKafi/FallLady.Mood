# FallLady.Mood

A modern ASP.NET Core web application for managing educational courses and teachers.

## Overview

FallLady.Mood is a web-based course management system that allows administrators to:
- Manage online and offline courses
- Handle teacher profiles and their course assignments
- Manage user accounts and roles
- Process course registrations

## Project Structure

The solution follows a clean architecture pattern with these main projects:

- **FallLady.Mood**: Main web application (ASP.NET Core MVC)
- **FallLady.Mood.Application**: Application logic and services
- **FallLady.Mood.Domain**: Domain models and business logic
- **FallLady.Mood.Persistance**: Data access and database context
- **FallLady.Mood.Framework.Core**: Core interfaces and utilities
- **FallLady.Mood.Infrastructure**: Infrastructure services

## Key Features

- **Course Management**
  - Support for both online and offline courses
  - Course scheduling with date and time management
  - Course material file management
  - Teacher assignment

- **Teacher Management**
  - Teacher profile management
  - Course assignment tracking
  - Teacher performance monitoring

- **User Management**
  - Role-based authentication
  - User registration and login
  - Admin user management

## Technical Stack

- **Backend**: ASP.NET Core MVC
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Architecture**: Clean Architecture with Domain-Driven Design principles
- **Dependency Injection**: Autofac
- **Frontend**: Bootstrap, jQuery

## Database Configuration

The application uses SQL Server as its database. Connection strings can be configured in:
- `appsettings.json`
- `appsettings.Development.json`

## Security

- Custom identity implementation with ASP.NET Core Identity
- Role-based authorization
- Secure password policies
- Protected admin area

## Areas

- **Admin Area**: Protected administrative interface for managing courses, teachers, and users
- **Public Area**: User-facing interface for course browsing and registration

This project serves as a demonstration of modern ASP.NET Core development practices and architectural patterns.
