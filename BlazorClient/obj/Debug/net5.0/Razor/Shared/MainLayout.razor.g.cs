#pragma checksum "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/Shared/MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0041b27e08d9687ebacd05d2db4ff69cf89279a"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorClient.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using BlazorClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/_Imports.razor"
using BlazorClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/Shared/MainLayout.razor"
using BlazorClient.LoginComponent;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-hm1telts54");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(3);
            __builder.AddAttribute(4, "Policy", "RequireLogIn");
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "sidebar");
                __builder2.AddAttribute(8, "b-hm1telts54");
                __builder2.OpenComponent<BlazorClient.Shared.NavMenu>(9);
                __builder2.CloseComponent();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(10, "\n    ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "main");
            __builder.AddAttribute(13, "b-hm1telts54");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "top-row px-4 h-auto m-10");
            __builder.AddAttribute(16, "b-hm1telts54");
            __builder.OpenComponent<BlazorClient.LoginComponent.Login>(17);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\n\n        ");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "content px-4");
            __builder.AddAttribute(21, "b-hm1telts54");
            __builder.AddContent(22, 
#nullable restore
#line 16 "/home/c/Desktop/RiderProjects/ChatSystem/BlazorClient/Shared/MainLayout.razor"
             Body

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
