import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from "@angular/common/http"
import { Observable } from "rxjs"

export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
  {
    const req1 = req.clone({
      headers: req.headers.append('magictoken', "DFGHFDGHGFHHFHFH"),
    });

    return next.handle(req1);
  }
}
