[Back to README](../README.md)

## General API Definitions


**Note**

The tests will use this sequence of api calls:

Creation of several products:

POST: http://ocelot-gateway:7777/products
```json
{
  "name": "null",
  "description": "Mouse ergonômico RGB com 8000 DPI",
  "price": 149.90,
  "stock": 50,
  "imageUrl": "https://example.com/mouse-gamer.jpg"
}
```


GET: http://ocelot-gateway:7777/products

```json
{
    "data": [
        {
            "id": "eec00a59-558f-4f68-a7ca-7a519317a604",
            "name": "null",
            "description": "Mouse ergonômico RGB com 8000 DPI",
            "price": 149.90,
            "stock": 50,
            "imageUrl": "https://example.com/mouse-gamer.jpg"
        }
    ],
    "status": "success",
    "message": "Operation completed successfully"
}

```
a
Sales Process

POST: http://ocelot-gateway:7777/sales

```json
Input:
{
  "customerId": "string",
  "customerName": "string",
  "branchId": "string",
  "branch": "string",
  "items": [
    {
      "productId": "string",
      "productName": "string",
      "quantity": 0,
      "unitPrice": 0
    }
  ]
}

output:
{
    "data": [
        {
            "id": "0d4bd5b6-127d-4d0f-9dbb-4a9630e6298d",
            "nummber": "S-20250426204609-1593ec5b",
            "customerId": "48d9574e-c293-48b7-86ea-1fe2de520fec",
            "customerName": "João da Silva",
            "date": "2025-04-26T20:46:09.235025Z",
            "taxValue": 20.00,
            "totalAmount": 40.80,
            "branch": "Filial São Paulo",
            "branchId": "48d9574e-c293-48b7-86ea-1fe2de520fea",
            "isCancelled": false,
            "items": [
                {
                    "id": "3f38da88-8359-48d2-8ee7-7ebf283af410",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
                    "productName": "Mouse Gamer Redragon",
                    "quantity": 14,
                    "unitPrice": 2.00,
                    "totalAmount": 28.00
                },
                {
                    "id": "8116f30e-9ece-429e-bb0e-f0cc41424a9d",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
                    "productName": "Mouse Gamer Redragon",
                    "quantity": 6,
                    "unitPrice": 1.00,
                    "totalAmount": 6.00
                }
            ]
        }
    ],
    "status": "success",
    "message": "Sales retrieved successfully"
}

```

List sells:

GET: http://ocelot-gateway:7777/sales


```json
{
	
    "data": [
        {
            "id": "0d4bd5b6-127d-4d0f-9dbb-4a9630e6298d",
            "nummber": "S-20250426204609-1593ec5b",
            "customerId": "48d9574e-c293-48b7-86ea-1fe2de520fec",
            "customerName": "João da Silva",
            "date": "2025-04-26T20:46:09.235025Z",
            "taxValue": 20.00,
            "totalAmount": 40.80,
            "branch": "Filial São Paulo",
            "branchId": "48d9574e-c293-48b7-86ea-1fe2de520fea",
            "isCancelled": false,
            "items": [
                {
                    "id": "3f38da88-8359-48d2-8ee7-7ebf283af410",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
                    "productName": "Mouse Gamer Redragon",
                    "quantity": 14,
                    "unitPrice": 2.00,
                    "totalAmount": 28.00
                },
                {
                    "id": "8116f30e-9ece-429e-bb0e-f0cc41424a9d",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
                    "productName": "Mouse Gamer Redragon",
                    "quantity": 6,
                    "unitPrice": 1.00,
                    "totalAmount": 6.00
                }
            ]
        },
        {
            "id": "e8cf1d10-fbf1-4c9a-8d35-1079b02fc240",
            "nummber": "S-20250426204755-7a3a7ec2",
            "customerId": "48d9574e-c293-48b7-86ea-1fe2de520fec",
            "customerName": "João da Silva",
            "date": "2025-04-26T20:47:55.640046Z",
            "taxValue": 20.00,
            "totalAmount": 40.80,
            "branch": "Filial São Paulo",
            "branchId": "48d9574e-c293-48b7-86ea-1fe2de520fea",
            "isCancelled": false,
            "items": [
                {
                    "id": "a511cf3d-ae31-41c9-87a0-9bf642b4eb4c",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
                    "productName": "Mouse Gamer Redragon",
                    "quantity": 14,
                    "unitPrice": 2.00,
                    "totalAmount": 28.00
                },
                {
                    "id": "eb4d5bc7-a052-479d-b987-c2cfe3cb61de",
                    "productId": "3fa85f64-5717-4562-b3fc-2c963f66afa8",
                    "productName": "Mouse Gamer Redragon",
                    "quantity": 6,
                    "unitPrice": 1.00,
                    "totalAmount": 6.00
                }
            ]
        }
    ],
    "status": "success",
    "message": "Sales retrieved successfully"
}

```

if sell above 20 identical items:

{	
	"type":"BadRequest",
	"error":"Invalid Sell",
	"detail":"You cannot buy more than 20 pices of same item"
}



Cancelling one sales:

PATCH: http://ocelot-gateway:7777/sales/{Id}

output:
```
{
  "data": true,
  "status": "success",
  "message": "Sale cancellation successfully"
}
```


## Error Handling

The API uses conventional HTTP response codes to indicate the success or failure of an API request. In general:

- 2xx range indicate success
- 4xx range indicate an error that failed given the information provided (e.g., a required parameter was omitted, etc.)
- 5xx range indicate an error with our servers

### Error Response Format

```json
{
  "type": "string",
  "error": "string",
  "detail": "string"
}
```

- `type`: A machine-readable error type identifier
- `error`: A short, human-readable summary of the problem
- `detail`: A human-readable explanation specific to this occurrence of the problem

Example error responses:

1. Resource Not Found
```json
{
  "type": "InvalidData",
  "error": "Price cannot be empty",
  "detail": "The sales with ID 12345 has the product XXXX with zero price"
}
```

For detailed error information, refer to the specific endpoint documentation.