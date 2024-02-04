
export class LiveMessage {
  constructor(public tenant: string, public command: string, public liveData: LiveDataEvent, public liveDevice: LiveDevice) {
  }
}


export class LiveDataEvent {

  constructor(public identifier: string, public tenant: string, public dataType: string, public macAddress: string, public value: number, public timestamp: number) {
  }

}

export class LiveDevice {

  constructor(public deviceId: string, public deviceName: string, public trackerAddress: string, public trackerName: string, userId: string, public userName: string, public trackerFirmware: string, public trackerBattery: string, public active: string) {
  }
}
