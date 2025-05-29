# Ventixe FeedbackService

A .NET 9 microservice for managing customer feedback and ratings in the Ventixe platform, providing comprehensive feedback collection and analytics capabilities.

## 🌐 Live Demo

**🚀 Deployed API**: [https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net](https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net)

**📖 API Documentation**: [https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net/swagger](https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net/swagger)

## 📋 Overview

The FeedbackService is a RESTful API microservice built with .NET 9 that manages customer feedback and rating operations for the Ventixe platform. It provides endpoints for creating, reading, and analyzing customer feedback with detailed rating categories and statistical insights.

## 🛠️ Technologies Used

- **.NET 9** - Latest version of .NET framework
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - Object-Relational Mapping (ORM)
- **SQL Server** - Database (configurable)
- **Swagger/OpenAPI** - API documentation
- **Clean Architecture** - Layered architecture pattern

## 🏗️ Architecture

The service follows Clean Architecture principles with clear separation of concerns:

```
FeedbackService/
├── Presentation/           # API controllers and configuration
│   ├── Controllers/        # REST API controllers
│   └── Program.cs         # Application entry point
├── Application/           # Business logic and services
│   ├── Interfaces/        # Service contracts
│   ├── Models/           # DTOs and view models
│   └── Services/         # Business logic implementation
└── Persistence/          # Data access layer
    ├── Contexts/         # Entity Framework DbContext
    ├── Entities/         # Database entities
    ├── Interfaces/       # Repository contracts
    └── Repositories/     # Data access implementation
```

## 🔧 Setup Instructions

### Prerequisites

- .NET 9 SDK
- SQL Server (LocalDB, Express, or Full)
- Visual Studio 2022 or JetBrains Rider (optional)

### Local Development

1. **Clone the repository**

   ```bash
   git clone <your-repo-url>
   cd FeedbackService
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Update database connection**
   Edit `appsettings.json` in the Presentation project:

   ```json
   {
     "ConnectionStrings": {
       "SqlConnection": "your-connection-string-here"
     }
   }
   ```

4. **Run database migrations**

   ```bash
   dotnet ef database update --project Persistence --startup-project Presentation
   ```

5. **Start the service**

   ```bash
   cd Presentation
   dotnet run
   ```

6. **Access API documentation**
   Navigate to `https://localhost:7002/swagger` (or the displayed URL)

## 📡 API Endpoints

### Feedback Management

| Method | Endpoint                         | Description             |
| ------ | -------------------------------- | ----------------------- |
| `GET`  | `/api/feedbacks`                 | Get all feedback        |
| `GET`  | `/api/feedbacks/{id}`            | Get feedback by ID      |
| `GET`  | `/api/feedbacks/event/{eventId}` | Get feedback by event   |
| `GET`  | `/api/feedbacks/statistics`      | Get feedback statistics |
| `POST` | `/api/feedbacks`                 | Create new feedback     |

### Request/Response Examples

#### Get All Feedback

```http
GET /api/feedbacks
```

**Response:**

```json
{
  "success": true,
  "result": [
    {
      "id": "feedback-id",
      "eventId": "event-id",
      "eventName": "Sample Event",
      "userId": "user-id",
      "userName": "John Doe",
      "content": "Great event, really enjoyed it!",
      "rating": 5,
      "venueRating": 4,
      "eventOrganizationRating": 5,
      "staffSupportRating": 5,
      "entertainmentQualityRating": 4,
      "foodAndBeveragesRating": 3,
      "valueForMoneyRating": 4,
      "categoryId": 1,
      "categoryName": "Music",
      "isAnonymous": false,
      "createdAt": "2024-04-20T10:00:00Z"
    }
  ]
}
```

#### Get Feedback Statistics

```http
GET /api/feedbacks/statistics
```

**Response:**

```json
{
  "success": true,
  "result": {
    "overallRating": 4.8,
    "totalReviews": 15545,
    "monthlyData": [
      {
        "month": "Jan",
        "rating1To3": 650,
        "rating4To5": 880
      },
      {
        "month": "Feb",
        "rating1To3": 700,
        "rating4To5": 920
      }
    ]
  }
}
```

#### Create Feedback

```http
POST /api/feedbacks
Content-Type: application/json

{
  "eventId": "event-id",
  "eventName": "Sample Event",
  "userId": "user-id",
  "userName": "John Doe",
  "content": "Excellent event organization and entertainment!",
  "rating": 5,
  "venueRating": 4,
  "eventOrganizationRating": 5,
  "staffSupportRating": 5,
  "entertainmentQualityRating": 5,
  "foodAndBeveragesRating": 4,
  "valueForMoneyRating": 4,
  "categoryId": 1,
  "categoryName": "Music",
  "isAnonymous": false
}
```

## 🗃️ Data Models

### CreateFeedbackRequest

```csharp
public class CreateFeedbackRequest
{
    [Required]
    public string EventId { get; set; }
    public string? EventName { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Content { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    // Detailed category ratings
    [Range(1, 5)]
    public int? VenueRating { get; set; }

    [Range(1, 5)]
    public int? EventOrganizationRating { get; set; }

    [Range(1, 5)]
    public int? StaffSupportRating { get; set; }

    [Range(1, 5)]
    public int? EntertainmentQualityRating { get; set; }

    [Range(1, 5)]
    public int? FoodAndBeveragesRating { get; set; }

    [Range(1, 5)]
    public int? ValueForMoneyRating { get; set; }

    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    public bool IsAnonymous { get; set; }
}
```

### Feedback Entity

```csharp
public class FeedbackEntity
{
    public string Id { get; set; }
    public string EventId { get; set; }
    public string EventName { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public int? CategoryId { get; set; }
    public bool IsAnonymous { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation property
    public CategoryEntity? Category { get; set; }
}
```

## 🎯 Features

### 📊 Feedback Collection

- **Multi-dimensional Ratings**: Overall rating plus specific category ratings
- **Anonymous Feedback**: Option for users to submit anonymous feedback
- **Event Association**: Link feedback to specific events
- **Rich Content**: Support for detailed text feedback

### 📈 Analytics & Statistics

- **Overall Ratings**: Average ratings across all feedback
- **Monthly Trends**: Track rating trends over time
- **Category Breakdown**: Ratings by different aspects (venue, staff, etc.)
- **Volume Metrics**: Total number of reviews and feedback

### 🔍 Filtering & Search

- **Event-based Filtering**: Get feedback for specific events
- **User-based Filtering**: Track feedback from specific users
- **Time-based Analysis**: Analyze feedback trends over time periods

## 🚀 Deployment

### Azure App Service

The service is deployed to Azure App Service with the following configuration:

- **Platform**: Azure App Service (Windows)
- **Runtime**: .NET 9
- **Database**: Azure SQL Database (or SQL Server)
- **CORS**: Enabled for cross-origin requests

### Deployment Commands

```bash
# Build for production
dotnet publish Presentation/Presentation.csproj -c Release -o ./publish

# Deploy to Azure (using Azure CLI)
az webapp deployment source config-zip \
  --name feedbackservice-a7cpfabadjd8c2dm \
  --resource-group your-resource-group \
  --src publish.zip
```

### Environment Configuration

Set the following application settings in Azure:

```json
{
  "ConnectionStrings__SqlConnection": "your-azure-sql-connection-string",
  "ASPNETCORE_ENVIRONMENT": "Production"
}
```

## 🔒 Security Features

- **CORS Configuration**: Allows cross-origin requests from frontend
- **Input Validation**: Model validation on all endpoints with range validation for ratings
- **Data Sanitization**: Protection against injection attacks
- **Anonymous Support**: Privacy protection for sensitive feedback

## 🧪 Testing

### Run Unit Tests

```bash
dotnet test
```

### API Testing with curl

```bash
# Get all feedback
curl -X GET "https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net/api/feedbacks"

# Get feedback statistics
curl -X GET "https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net/api/feedbacks/statistics"

# Create new feedback
curl -X POST "https://feedbackservice-a7cpfabadjd8c2dm.centralus-01.azurewebsites.net/api/feedbacks" \
  -H "Content-Type: application/json" \
  -d '{
    "eventId": "sample-event-id",
    "eventName": "Sample Event",
    "userId": "user-123",
    "userName": "John Doe",
    "content": "Great event!",
    "rating": 5,
    "venueRating": 4,
    "eventOrganizationRating": 5,
    "staffSupportRating": 5,
    "isAnonymous": false
  }'
```

## 📊 Rating Categories

The service supports detailed ratings across multiple categories:

| Category                  | Description                                      |
| ------------------------- | ------------------------------------------------ |
| **Overall Rating**        | General satisfaction rating (1-5)                |
| **Venue Rating**          | Quality and suitability of the venue             |
| **Event Organization**    | How well the event was organized and managed     |
| **Staff Support**         | Quality of staff assistance and support          |
| **Entertainment Quality** | Quality of performances, speakers, or activities |
| **Food & Beverages**      | Quality of catering and refreshments             |
| **Value for Money**       | Whether the event provided good value            |

## 🔄 Integration

### Frontend Integration

The service integrates with the Ventixe Frontend application:

```javascript
// Frontend service usage
import { feedbackService } from "./services/feedbackService";

// Get all feedback
const feedback = await feedbackService.getAllFeedback();

// Get feedback statistics
const stats = await feedbackService.getFeedbackStats();

// Create feedback
const newFeedback = await feedbackService.createFeedback({
  eventId: "event-123",
  eventName: "Music Festival",
  userId: "user-456",
  userName: "Jane Doe",
  content: "Amazing experience!",
  rating: 5,
  venueRating: 4,
  eventOrganizationRating: 5,
  isAnonymous: false,
});
```

### Event Service Integration

Feedback is linked to events from the EventService:

- Event IDs are validated against the EventService
- Event names are fetched and stored for better user experience
- Feedback statistics can be aggregated per event

## 🔧 Configuration

### Development Configuration (appsettings.Development.json)

```json
{
  "ConnectionStrings": {
    "SqlConnection": "Server=(localdb)\\mssqllocaldb;Database=VentixeFeedbackDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### Production Configuration

```json
{
  "ConnectionStrings": {
    "SqlConnection": "your-production-connection-string"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  }
}
```

## 🐛 Troubleshooting

### Common Issues

1. **Database Connection Errors**

   - Verify connection string in appsettings.json
   - Ensure SQL Server is running
   - Check firewall settings for Azure SQL

2. **Rating Validation Errors**

   - Ensure all ratings are between 1-5
   - Verify required fields are provided
   - Check data types match the model

3. **CORS Errors**
   - Verify CORS is configured in Program.cs
   - Check allowed origins in production

## 📈 Performance Considerations

- **Async Operations**: All database operations use async/await patterns
- **Indexing**: Database indexes on frequently queried fields (EventId, UserId)
- **Caching**: Consider implementing response caching for statistics
- **Pagination**: Implement for large feedback datasets

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Support

For support and questions:

- Check the API documentation at `/swagger`
- Create an issue in the GitHub repository
- Contact the development team

---

Built with ❤️ using .NET 9 and deployed on Azure App Service
