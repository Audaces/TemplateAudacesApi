using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TemplateAudacesApi.Models;
using TemplateAudacesApi.Utils;

namespace TemplateAudacesApi.Controllers;

[Route("audaces/idea/api")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet, Route("version")]
    public ActionResult<string> Version()
    {
        return Ok(1.6);
    }

    [HttpPost]
    [Route("v1/user/login")]
    [Consumes("application/x-www-form-urlencoded")]
    public ActionResult<LoginResponse> Login([FromForm] string username, [FromForm] string password)
    {
        if (username == null || password == null)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            return new LoginResponse { error = "invalid_grant" };
        }

        var user = UserRepository.Get(username, password);
        if (user == null)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            return new LoginResponse { error = "invalid_grant" };
        }

        var token = TokenService.GenerateToken(user);

        return new LoginResponse
        {
            access_token = token,
            expires_in = 7200,
            token_type = "Bearer"
        };
    }

    [HttpGet, Route("v1/query")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IEnumerable<Object> Query([FromQuery] string uid
        , [FromQuery] string reference
        , [FromQuery] string type
        , [FromQuery] string product_group
        , [FromQuery] string supplier
        , [FromQuery] string description
        , [FromQuery] string collection)
    {
        List<Object> items = new List<Object>();

        if (!string.IsNullOrEmpty(uid))
        {
            // TODO: adicionar o item buscado e retornar
            return items;
        }

        if (!string.IsNullOrEmpty(reference))
        {
            // TODO: adicionar os itens buscado pela referencia (material, medida, modelo, etc) e retornar
            return items;
        }

        if (type == "raw_material")
        {
            // raw_material: variantes representam variações de cor do material.
            // Cada variante usa o objeto Color com uid, rgb e value.
            items.Add(new Material
            {
                type         = "raw_material",
                uid          = "BTN-ID1",
                name         = "Button 1",
                reference    = "BTN1",
                description  = "Small button",
                value        = 10.49,
                measure_unit = "UN",
                product_group= "Buttons",
                supplier     = "ACME INC",
                notes        = "A small plastic button",
                variants     = new List<Variant>
                {
                    new Variant
                    {
                        label = "BTN1-WHITE",
                        color = new Color { uid = "WHITE", value = "White", rgb = "#FFFFFF" },
                        value = "10.49"
                    },
                    new Variant
                    {
                        label = "BTN1-BLACK",
                        color = new Color { uid = "BLACK", value = "Black", rgb = "#000000" },
                        value = "12.00"
                    }
                }
            });
        }
        else if (type == "finished_product")
        {
            // finished_product: a cor NÃO vai no objeto Color da variante.
            // A cor é representada como CustomField (com options) no nível do produto.
            // Cada variante representa uma combinação cor/tamanho e carrega seus items (componentes).
            items.Add(new FinishedProduct
            {
                type         = "finished_product",
                uid          = "039292",
                name         = "POLO_SHIRT 3",
                reference    = "039292",
                description  = "MENS POLO SHIRT",
                value        = 15,
                product_group= "Shirts",
                collection   = "HIGHSTIL SUMMER 2017",
                notes        = "Lyle & Scott 2",
                custom_fields = new List<CustomField>
                {
                    new CustomField
                    {
                        name     = "Cor",
                        type     = "string",
                        value    = "White",
                        editable = true,
                        options  = new List<string> { "White", "Black", "Navy" }
                    }
                },
                variants = new List<Variant>
                {
                    new Variant
                    {
                        label = "039292-WHITE-M",
                        items = new List<Item>
                        {
                            new Item { uid = "BTN-WHITE", name = "Button White", type = "raw_material", measure_unit = "UN", value = 0.5 }
                        }
                    },
                    new Variant
                    {
                        label = "039292-BLACK-M",
                        items = new List<Item>
                        {
                            new Item { uid = "BTN-BLACK", name = "Button Black", type = "raw_material", measure_unit = "UN", value = 0.5 }
                        }
                    }
                }
            });
        }
        else if (type == "activity")
        {
            items.Add(new Activity
            {
                type        = "activity",
                uid         = "ACT001",
                name        = "Wash",
                reference   = "LV001",
                description = "Wash the whole fabric",
                value       = 0.5,
                measure_unit= "min",
                time        = 30,
                notes       = "Repeated two times",
                sector      = "SCT1",
                machine     = "MC1"
            });
        }
        else if (type == "generic")
        {
            items.Add(new Generic
            {
                type       = "generic",
                uid        = "CLN001",
                reference  = "CLNABC",
                name       = "cliente ABC",
                address    = "Rua João Paulo 400",
                phone      = "011 987654321",
                description= "cliente de São Paulo"
            });
        }
        else if (type == "measure")
        {
            items.Add(new Measure
            {
                type      = "measure",
                uid       = "MSR001",
                name      = "gola",
                reference = "MSRGola",
                notes     = "Testeeeee",
                value     = 1.5,
                measure_unit = "mm",
                last_modified = "2018-09-07T12:31Z",
                values = new MeasureValues
                {
                    P = 1.2,
                    M = 1.5,
                    G = 1.8,
                    order = "P;M;G"
                }
            });
        }

        return items;
    }

    [HttpPost]
    [Route("v1/garment")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public StatusResponse Garment([FromBody] Garment value, [FromQuery] string? uid)
    {
        StatusResponse ret = new StatusResponse
        {
            uid = "",
            status = "not found",
            message = "Garment not save on the server"
        };
        return ret;
    }

    [HttpGet]
    [Route("v1/picture")]
    [Produces("application/x-binary")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<Byte[]> Picture([FromQuery] string uid)
    {
        Image? image = null; // TODO: buscar a imagem pelo uid informado
        if (image != null)
        {
            var filePath = image.get_image_name();
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return new FileContentResult(bytes, "application/x-binary")
            {
                FileDownloadName = image.get_image_name()
            };
        }

        return null;
    }

    [HttpPost]
    [Route("v1/garment/picture")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<object> GarmentPicture([FromQuery] string garment_uid
        , [FromQuery] string description
        , [FromQuery] string picture_uid)
    {
        StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
        var ms = new MemoryStream();
        reader.BaseStream.CopyTo(ms);

        return new StatusResponse { uid = "7678", status = "ok", message = "a message describing the response of the request" };
    }

    [HttpDelete]
    [Route("v1/garment/picture")]
    [SwaggerOperation(Summary = "Remove picture from server")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<object> RemovePicture([FromQuery] string garment_uid, [FromQuery] string picture_uid)
    {
        var retorno = new StatusResponse
        {
            status = "removed",
            uid = picture_uid
        };
        return Ok(retorno);
    }
}
