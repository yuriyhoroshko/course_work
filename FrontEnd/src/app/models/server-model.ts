export interface ServerModel {
    serverName: string;
    ipAddress: string;
    userId: number;
    counters: ServerPerformanceCounter[];
};

export interface ServerPerformanceCounter {
    counterName: string;
    counterId: number;
}