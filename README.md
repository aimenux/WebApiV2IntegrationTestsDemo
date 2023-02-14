[![CI](https://github.com/aimenux/WebApiV2IntegrationTestsDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/WebApiV2IntegrationTestsDemo/actions/workflows/ci.yml)

# WebApiV2IntegrationTestsDemo
```
Using integration tests with web api v2 projects
```

> In this repo, i m exploring various ways in order to setup integration tests with [web api v2](https://learn.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api) projects
>
> :one: `Example01` use controller(s) without dependency injection
>
> :two: `Example02` use controller(s) and service(s) with [unity dependency injection](http://unitycontainer.org)
>
> :three: `Example03` use controller(s) and service(s) with [ninject dependency injection](http://www.ninject.org)
>
> :four: `Example04` use controller(s) and service(s) with [autofac dependency injection](https://autofac.org/)
>
> :bulb: Integration tests are based on the [in-memory HttpServer](https://learn.microsoft.com/en-us/previous-versions/aspnet/hh834055(v=vs.108))
>

**`Tools`** : vs22, net 4.8, web api v2, unity, ninject, autofac, integration-testing
