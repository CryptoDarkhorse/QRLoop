import {
    getFrames,
    parseFrames,
    isComplete,
    getFrameData,
    getProgress
} from './my_lib';

import { Buffer } from "buffer";

export function GetFrames(data, dataSize = 120, loops = 1) {
    return getFrames(data, dataSize, loops);
}

export function ParseFrames(s, chunk) {
    s = parseFrames(s, chunk);
    for (var j = 0; j < s.frames.length; j++) {
        if (!Buffer.isBuffer(s.frames[j].data)) {
            s.frames[j].data = Buffer.from(s.frames[j].data);
        }
    }
    if (isComplete(s)) {
        return ["1", getFrameData(s).toString()];
    } else {
        return ["0", s];
    }
}

export function IsComplete(s) {
    return isComplete(s);
}

export function GetFrameData(s) {
    return getFrameData(s).toString();
}

export function GetProgress(s) {
    return getProgress(s);
}