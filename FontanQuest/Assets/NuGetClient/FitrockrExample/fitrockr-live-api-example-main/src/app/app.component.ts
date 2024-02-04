import {Component} from '@angular/core';
import {first, Observable} from 'rxjs';
import {environment} from '../environments/environment';
import * as Stomp from 'stompjs';
import * as SockJS from 'sockjs-client';
import {LiveDevice, LiveMessage} from './live-message';
import {HttpClient} from '@angular/common/http';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  static readonly LIVE_TOPIC = '/topic/live';
  static readonly MAX_MESSAGES = 25;

  stompClient: any;
  connected = false;
  messages: LiveMessage[] = [];
  error: any;
  devices: LiveDevice[] = [];

  constructor(private http: HttpClient) {
  }

  connect() {
    this.connectTo(AppComponent.LIVE_TOPIC, () => {
      this.connected = true;
    }).subscribe({
      next: message => {
        var arrLength = this.messages.length;
        if (message.command === "Data") {
          this.messages.push(message);
          if (arrLength > AppComponent.MAX_MESSAGES) {
            this.messages.splice(0, arrLength - AppComponent.MAX_MESSAGES);
          }
        }

        if(message.command === "DeviceAdded") {
          this.devices.push(message.liveDevice);
        }

      }, error: error => {
        this.connected = false;
        this.error = error;
      }
    });
  }

  connectTo(topic: string, connectFn: () => void): Observable<LiveMessage> {

    return new Observable(subscriber => {

      const ws = new SockJS(environment.stompUrl, null, {
        transports: ['xhr-streaming'],
        // @ts-ignore
        headers: {'X-API-Key': environment.apiKey, 'X-Tenant': environment.tenantId}
      });
      this.stompClient = Stomp.over(ws);
      this.stompClient.reconnect_delay = 5000;
      this.stompClient.debug = null;
      this.stompClient.connect({'X-API-Key': environment.apiKey, 'X-Tenant': environment.tenantId}, () => {
        connectFn();
        // @ts-ignore
        this.stompClient.subscribe(topic + '/' + environment.tenantId, message => {
          const liveEvent: LiveMessage = JSON.parse(message.body);
          subscriber.next(liveEvent);
        });
      }, subscriber.error);

      ws.onerror = function () {
        subscriber.error('error');
      };

      ws.onclose = function () {
        subscriber.error('close');
      };
    });

  }

  disconnect() {
    if (this.stompClient !== null) {
      this.stompClient.disconnect(() => {
        this.stompClient = null;
      });
    }
  }

  ping() {
    this.http.get<void>(`${environment.restUrl}/live/control/ping`, {headers: {'X-API-Key': environment.apiKey, 'X-Tenant': environment.tenantId}}).pipe(first()).subscribe(() => {});
  }

  start() {
    this.http.get<void>(`${environment.restUrl}/live/control/start`, {headers: {'X-API-Key': environment.apiKey, 'X-Tenant': environment.tenantId}}).pipe(first()).subscribe(() => {});
  }

  stop() {
    this.http.get<void>(`${environment.restUrl}/live/control/stop`, {headers: {'X-API-Key': environment.apiKey, 'X-Tenant': environment.tenantId}}).pipe(first()).subscribe(() => {});
  }
}
