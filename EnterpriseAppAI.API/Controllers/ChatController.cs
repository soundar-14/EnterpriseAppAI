namespace EnterpriseAppAI.API.Controllers;

using EnterpriseAppAI.Application.AI.Interfaces;
using EnterpriseAppAI.Application.AI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly ILogger<ChatController> _logger;

    public ChatController(IChatService chatService, ILogger<ChatController> logger)
    {
        _chatService = chatService;
        _logger = logger;
    }

    /// <summary>
    /// Send a message to the enterprise AI assistant and get a response.
    /// </summary>
    /// <param name="request">The chat request containing the user message and optional conversation history.</param>
    /// <param name="cancellationToken">Cancellation token for the request.</param>
    /// <returns>A chat response containing the AI answer and updated conversation history.</returns>
    [HttpPost]
    public async Task<ActionResult<ChatResponse>> Ask(
        [FromBody] ChatRequest request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.UserMessage))
        {
            return BadRequest("User message cannot be empty.");
        }

        _logger.LogInformation("Chat endpoint called with message: {Message}", request.UserMessage);

        var response = await _chatService.AskAsync(request, cancellationToken);

        return Ok(response);
    }
}
