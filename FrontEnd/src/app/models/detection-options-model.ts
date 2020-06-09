export interface PredictionOptions
{
    beginDate: Date;
    endDate: Date;
    serverId: number;
    counterName: string;
    options: Options;
}

export interface Options {
    algorithm: number;
    confidence: number;
    trainingWindowSize: number;
    seasonalityWindowSize: number;
    pValueHistoryLength: number;
    windowSize: number;
    threshold: number;
    judgementWindowSize: number;
}
