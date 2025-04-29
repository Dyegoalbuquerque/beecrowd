[Back to README](../README.md)

## Project Structure

The project is be structured as follows:

``` 
root
├── src/
│ ├── SalesApi/ 		        # Sales API code
│ │ ├── SalesApi.Domain 	    # Domain for the API
│ │ ├── SalesApi.Application    # Application for the API
│ │ ├── SalesApi.Infrastructure # Application for the API
│ │ ├── SalesApi.Presentation   # Application for the API
│ │ ├── Dockerfile 		        # Dockerfile for the API
│ └── Gateway/ 			        # Ocelot Gateway code
│   ├── Dockerfile 		        # Dockerfile for the Gateway
│   └── ocelot.json 		    # Ocelot route configuration file
├── docker-compose.yml 	        # Orchestrate all services
├── SalesApi.sln                # File solution
```
