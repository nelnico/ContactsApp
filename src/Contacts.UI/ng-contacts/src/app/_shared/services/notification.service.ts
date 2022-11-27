import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  success(title: string, message: string) {
    alert(`SUCCESS: ${title} - ${message}`)
  }
  info(title: string, message: string) {
    alert(`INFO: ${title} - ${message}`)
  }
  warn(title: string, message: string ) {
    alert(`WARN: ${title} - ${message}`)
  }
  error(title: string, message: string ) {
    alert(`ERROR: ${title} - ${message}`)
  }


}
