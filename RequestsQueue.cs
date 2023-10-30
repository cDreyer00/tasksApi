using System.Collections;

public class RequestsQueue
{
    Queue requests = new();
}

public abstract class Request
{

}

public class AddRequest : Request
{

}

public class DeleteRequest : Request
{

}