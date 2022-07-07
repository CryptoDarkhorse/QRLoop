import {
    dataToFrames,
    parseFramesReducer,
    areFramesComplete,
    framesToData,
    progressOfFrames
} from "qrloop";

export function getFrames(data, dataSize, loops) {
    return dataToFrames(data, dataSize, loops);
}

export function parseFrames(s, chunk) {
    return parseFramesReducer(s, chunk);
}

export function isComplete(s) {
    return areFramesComplete(s);
}

export function getFrameData(s) {
    return framesToData(s);
}

export function getProgress(s) {
    return progressOfFrames(s);
}