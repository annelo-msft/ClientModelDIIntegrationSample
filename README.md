# ClientModelDIIntegrationSample

## Overview

 This sample does these six things:

1. App Program: [Register client with service collection: builder.AddClient](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/6dbf4467887be2e2b93890d5af0f554b7131e366/AspireIntegrationToy/AspireIntegrationToy/Program.cs#L22)
2. Extension: [Get endpoint from configuration](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L17)
3. Extension: [Add options to service collection](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L23)
4. Extension: [Add client creation delegate: IServiceProvider => TClient](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L27C7-L27C76)
5. App Page: [Code behind/PageModel constructor takes client](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/AspireIntegrationToy/Pages/Index.cshtml.cs#L11)
6. App Page: [Call client from request callback](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/AspireIntegrationToy/Pages/Index.cshtml.cs#L21)

## Open Questions

1. [Is it better to add an AddClient extension method as an extension to a host or service collection?](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L11)
    1. If we took a service collection, would we be able to access the app configuration settings?
	  2. I assume in a builder pattern you would return a builder, but [is there a convention to follow there?](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L39)
2. [Does this look like a good way to add client options, or is there a better pattern to follow for that?](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L24)
    1. [How we access options](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/Microsoft.Extensions.ClientModel/ClientModelExtensions.cs#L30) seems like it would rely on the answer to 2 ... what's best for that?
3.  Does [this part](https://github.com/annelo-msft/ClientModelDIIntegrationSample/blob/main/AspireIntegrationToy/AspireIntegrationToy/Pages/Index.cshtml.cs#L12) work because of the DI system?  What's happening there and how does it work?

## Running the sample

To run locally, use the SCM version in [this branch](https://github.com/annelo-msft/azure-sdk-for-net/tree/aspire-aoai-demo).


